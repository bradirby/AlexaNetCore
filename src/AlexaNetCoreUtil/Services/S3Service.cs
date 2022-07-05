using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using AlexaNetCore.Interfaces;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace AlexaNetCore.Util.Services
{
    public interface IS3Service
    {
        Task<T> ReadFromS3Async<T>(string keyName, string bucketName = "") where T : class;
        Task WriteToS3Async<T>(T obj, string keyName, string bucketName = "") where T : class;

    }


    public class LocalStorageS3Service : IS3Service
    {
        private string rootFolder;

        public LocalStorageS3Service(string root)
        {
            rootFolder = root;
        }

        public async Task<T> ReadFromS3Async<T>(string keyName, string bucketName = "") where T : class
        {
            if (keyName.Length > 50) keyName = keyName.Substring(0, 50);
            await using var r = File.OpenRead(Path.Combine(rootFolder, keyName + ".json"));
            return await JsonSerializer.DeserializeAsync<T>(r);
        }

        public async Task WriteToS3Async<T>(T obj, string keyName, string bucketName = "") where T: class
        {
            if (keyName.Length > 50) keyName = keyName.Substring(0, 50);
            var json = JsonSerializer.Serialize(obj);
            await File.WriteAllTextAsync(Path.Combine(rootFolder, keyName + ".json"), json);        }
    }

    public class S3Service : IS3Service
    {
        private AmazonS3Client? Client
        {
            get
            {
                if (_client != null) return _client;
                Logger?.Debug("Creating S3 client");
                _client = new AmazonS3Client(AccessKey, SecretKey, Endpoint);
                return _client;
            }
        }

        private AmazonS3Client _client;
        private string AccessKey;
        private string SecretKey;
        private RegionEndpoint Endpoint;
        private string DefaultBucketName;
        private IAlexaMessageLogger Logger;


        public S3Service(string accessKey, string secretKey, RegionEndpoint regionEndpoint, string defaultBucketName, IAlexaMessageLogger log)
        {
            AccessKey = accessKey;
            SecretKey = secretKey;
            Endpoint = regionEndpoint;
            DefaultBucketName = defaultBucketName;
            Logger = log; 
        }


        /// <summary>
        /// Read from an S3 Bucket
        /// </summary>
        /// <param name="bucketName">This is the Access Point Alias for the bucket</param>
        /// <param name="keyName">This is the name of the object to retrieve, prefaced by folder name if necessary.  No leading slash</param>
        /// <returns>The object requested or Null if no object exists</returns>
        public async Task<T> ReadFromS3Async<T>(string keyName, string bucketName = "") where T: class
        {

            if (bucketName == "") bucketName = DefaultBucketName;
            Logger?.Debug($"reading {keyName} from bucket {bucketName}");
            try
            {
                var req = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };

                var ms = new MemoryStream();
                using (var getObjectResponse = await Client.GetObjectAsync(req))
                {
                    await getObjectResponse.ResponseStream.CopyToAsync(ms);
                }

                ms.Position = 0;
                var s3Str = await new StreamReader(ms).ReadToEndAsync();
                return JsonSerializer.Deserialize<T>(s3Str);
            }
            catch (AmazonS3Exception awsExc) when (awsExc.ErrorCode == "NoSuchKey")
            {
                //the requested file does not exist
                Logger?.Debug($"Requested file {keyName} does not exist");
                return null;
            }
            catch (Exception e)
            {
                Logger?.Error(e, $"Exception reading key {keyName} and bucket {bucketName}");
                return null;
            }
        }



        /// <summary>
        /// Writes to an S3 Bucket.  This will overwrite existing objects with no warning.
        /// </summary>
        /// <param name="bucketname">This is the Access Point Alias for the bucket</param>
        /// <param name="keyName">This is the name of the object to retrieve, prefaced by folder name if necessary.  No leading slash</param>
        /// <returns>The object requested or Null if no object exists</returns>
        public async Task WriteToS3Async<T>(T obj, string keyName, string bucketName = "") where T: class
        {

            if (bucketName == "") bucketName = DefaultBucketName;
            Logger?.Debug($"writing {keyName} from bucket {bucketName}");

            try
            {
                var objStr = JsonSerializer.Serialize(obj);

                var memstring = new ASCIIEncoding().GetBytes(objStr);
                using var memStream = new MemoryStream(objStr.Length);
                memStream.Write(memstring, 0, memstring.Length);

                using var tranUtility = new Amazon.S3.Transfer.TransferUtility(Client);
                await tranUtility.UploadAsync(memStream, bucketName, keyName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
