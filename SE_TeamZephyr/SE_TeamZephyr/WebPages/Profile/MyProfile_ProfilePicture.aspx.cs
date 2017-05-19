using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_TeamZephyr.Profile
{
    public partial class MyProfile_ProfilePicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                using (var context = new IdentityDBContext())
                {
                    var currentUserID = Context.User.Identity.GetUserId();

                    ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == currentUserID);

                    // If the user has a profile picture
                    if(currentUser.ProfilePicture != null)
                    {
                        // Set the image box as their image
                        string base64String = Convert.ToBase64String(currentUser.ProfilePicture, 0, currentUser.ProfilePicture.Length);

                        ImageBox.ImageUrl = "data:image/jpeg;base64," + base64String;

                    }

                }

            }
        }

        public void UploadImage(object sender, EventArgs e)
        {

            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {

                        HttpPostedFile imageFile = FileUploadControl.PostedFile;

                        string filename = Path.GetFileName(FileUploadControl.FileName);

                        MemoryStream target = new MemoryStream();
                        imageFile.InputStream.CopyTo(target);

                        byte[] data = target.ToArray();

                        // 

                        using (var context = new IdentityDBContext())
                        {
                            var currentUserID = Context.User.Identity.GetUserId();

                            ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == currentUserID);

                            currentUser.ProfilePicture = data;

                            context.SaveChanges();
                        }

                        // Convert image back into a Base64, and set the image box to the image

                        string base64String = Convert.ToBase64String(data, 0, data.Length);

                        ImageBox.ImageUrl = "data:image/jpeg;base64," + base64String;

                        StatusLabel.Text = "Upload status: File uploaded!";

                        //FileUploadControl.SaveAs(Server.MapPath("~/") + filename);

                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }


        }

    }
}