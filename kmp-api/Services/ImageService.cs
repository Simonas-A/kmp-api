using Firebase.Auth;
using Firebase.Storage;

namespace kmp_api.Controllers
{
    public class ImageService
    {
        private string _firebaseStorageBucket = "BUCKET";

        public Stream ConvertBase64ToStream(string imageFromRequest)
        {
            byte[] imageStringToBase64 = Convert.FromBase64String(imageFromRequest);
            StreamContent streamContent = new(new MemoryStream(imageStringToBase64));
            return streamContent.ReadAsStream();
        }

        public async Task<string> UploadImageToFirebase(Stream stream, string imageName)
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();

            FirebaseStorageTask storageManager = new FirebaseStorage(
                                _firebaseStorageBucket,
                                new FirebaseStorageOptions
                                {
                                    ThrowOnCancel = true
                                })
                            .Child(imageName)
                            .PutAsync(stream, cancellationToken.Token);

            string imageFromFirebaseStorage;
            imageFromFirebaseStorage = await storageManager;

            return imageFromFirebaseStorage;
        }
    }
}