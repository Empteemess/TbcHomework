Project Setup and Usage Guide
```env

📌 Setup Instructions

🛠️ Environment Configuration

Create a .env file in the root directory with the following keys:


DB_CONNECTION_STRING=<your db connection string> 
AWS_STORAGE_BUCKET_NAME=<aws bucket name>
AWS_ACCESS_KEY_ID=<your AWS access key>
AWS_SECRET_ACCESS_KEY=<your AWS secret key>
DEFAULT_IMAGE=<default pre-uploaded image path>

🗄️ Database Management

➕ Add Migrations

Run the following command to add a migration:

dotnet ef migrations add <migrationName> --project Infrastructure --startup-project Web.api

🔄 Update Database

Apply the migrations with:

dotnet ef database update --project Infrastructure --startup-project Web.api

🖼️ Image Upload Process

To upload an image, follow these steps:

Get Pre-Signed URL

Send a request to:

GET http://localhost:5126/Storage

Response: Returns a PreSignedUrl and FilePath.

Upload the Image

Use the PreSignedUrl to upload the image directly to the S3 bucket.

Update User Image

Send a request to:

POST http://localhost:5126/User/image

Request Body: Include user ID and Image Path to update the user image.
