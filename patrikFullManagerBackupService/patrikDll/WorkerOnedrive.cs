using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.OneDrive.Sdk;
using Microsoft.OneDrive.Sdk.WindowsForms;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;





namespace patrikDll{
    public class WorkerOnedrive {

        public static async Task<IOneDriveClient> signIn(string msaClientId, string msaReturnUrl, string[] scopes) {
            try {
                IOneDriveClient oneDriveClient = await OneDriveClient.GetSilentlyAuthenticatedMicrosoftAccountClient(msaClientId, msaReturnUrl, scopes, getRefreshToken());
                Debug.WriteLine("athenticated  is ok");
                return oneDriveClient;
                /*serios error after implements routine of handling error*/
            } catch(OneDriveException errorOneDriver) {
                /*serios error after implements routine of handling error*/
                Debug.WriteLine("athenticated  is fail problens in onedriver");
                Debug.WriteLine(errorOneDriver.ToString());
                return null;
            } catch(Exception error) {
                Debug.WriteLine(error.ToString());
                Debug.WriteLine("athenticated  is fail problens in code c#");
                return null;
            }

        }

        public static async Task<string> generatorRefreshToken(string msaClientId, string msaReturnUrl, string[] scopes) {
            try {
                IOneDriveClient oneDriveClient = OneDriveClient.GetMicrosoftAccountClient(msaClientId, msaReturnUrl, scopes, webAuthenticationUi: new FormsWebAuthenticationUi());
                AccountSession accountSession = await oneDriveClient.AuthenticateAsync();
                return accountSession.RefreshToken;
            } catch(OneDriveException errorOneDriver) {
                Debug.WriteLine(errorOneDriver.ToString());
                return null;
            } catch(Exception error) {
                Debug.WriteLine(error.ToString());
                return null;
            }

        }
        public static string getRefreshToken() {
            /*after return value database or file encrypted*/
            return "MCX3RMKkDoox6VgrulJSxnacs85vPuZ!Odaxl2!Nr*GfCUmVhhQwqrYdeYZxIyux6lb7brqrkbe*9XO44xAPgP7kQAIcWXVHV7HNGs5PVKXsdjwUksd5Pjn0d3t8N5LxLmdPZDBRZ64M1TPvilltTeuNkH0kZBSmbp7UG6u35N9SSXk7zUvC6mF3PkwWOoLq7kdW6Caw*76dhNQuXsuJYZQF!Pz!IFvRE2tU8fvdvjfBYooHYgOw8n00HCSXABpTgDJ1xNAen776tHveuW17LWx*eRHHn!TommqcqhDbmKffdoQlluCpxSjK!EKBmCT6OyDWKQmte5O52K7Bp9mE7dMhztTEZRnH1embB26XX6UaqdHGCHOf16PVEmmxJpMtkdQDCNPMXYKofBUttLWPL*4k$";
        }

        public async static Task<Item> createFolder(IOneDriveClient oneDriveClient, String newFolder) {
            try {
                return await oneDriveClient.Drive.Root.ItemWithPath(newFolder).Request().CreateAsync(new Item { Folder = new Folder() });

            } catch(OneDriveException errorOneDriver) {
                Debug.WriteLine(errorOneDriver.ToString());
                return null;
            } catch(Exception error) {
                Debug.WriteLine(error.ToString());
                return null;
            }
        }

        public async static Task<bool> deleteFolder(IOneDriveClient oneDriveClient, String newFolder) {
            try {
                await oneDriveClient.Drive.Root.ItemWithPath(newFolder).Request().DeleteAsync();
                return true;
            } catch(OneDriveException errorOneDriver) {
                Debug.WriteLine(errorOneDriver.ToString());
                return false;
            } catch(Exception error) {
                Debug.WriteLine(error.ToString());
                return false;
            }
        }


        public async static Task<Item> uploadFile(IOneDriveClient oneDriveClient, String local, String name) {
            Stream contentStream = WorkerFile.readFileStream(local, name);
              try {                
                Debug.WriteLine(DateTime.Now);
                /*timeout occurs in 1 minutes and 40 seconds os execution this routine */
                var uploadedItem = await oneDriveClient.Drive.Root.ItemWithPath(Path.Combine(local,name)).Content.Request().PutAsync<Item>(contentStream);
                /*https://dev.onedrive.com/items/upload.htm*/
                Debug.WriteLine(DateTime.Now);
                return uploadedItem;
                // https://msdn.microsoft.com/en-us/magazine/mt632271.aspx
            } catch(OneDriveException errorOneDriver) {
                Debug.WriteLine(DateTime.Now);
                Debug.WriteLine(errorOneDriver.ToString());
                MessageBox.Show(errorOneDriver.ToString() + "onedriver");
                return null;
            } catch(Exception error) {
                Debug.WriteLine(error.ToString());
                MessageBox.Show(error.ToString());
                return null;
            }

        }

    }
}





