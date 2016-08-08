using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace patrikSystemBackupDll {
    public class Intelligence {
        public enum searchDateFile {
            GetCreationTime,
            GetCreationTimeUtc,
            GetLastWriteTime,
            GetLastWriteTimeUtc
        };
        public static List<StringDatetime> getFileNameDateCreate(String sourceDirectory, int numberGetNameAndDatatime, bool ascendingIsTheQuestion, int typeSearchDateFile = 0, string extension = "*") {
            List<StringDatetime> nameDateList = new List<StringDatetime>();
            if (Directory.Exists(sourceDirectory)) {
                if (numberGetNameAndDatatime > 0) {
                    string[] nameFiles = Directory.GetFiles(sourceDirectory, extension);
                    foreach (string s in nameFiles) {
                        StringDatetime nameDate;
                        nameDate.first = Path.GetFileName(s);
                        // nameDate.second = File.GetCreationTime(s); 
                     
                        switch (typeSearchDateFile) {
                            case (int)searchDateFile.GetCreationTime: nameDate.second = File.GetCreationTime(s);
                                break;
                            case (int)searchDateFile.GetCreationTimeUtc: nameDate.second = File.GetCreationTimeUtc(s);
                                break;
                            case (int)searchDateFile.GetLastWriteTime: nameDate.second = File.GetLastWriteTime(s);
                                break;
                            case (int)searchDateFile.GetLastWriteTimeUtc: nameDate.second = File.GetLastWriteTimeUtc(s);
                                break;
                            default:
                                nameDate.second = File.GetCreationTime(s);
                                break;
                        }

                        nameDateList.Add(nameDate);
                    }

                    if (numberGetNameAndDatatime > nameDateList.Count) {
                        numberGetNameAndDatatime = nameDateList.Count;
                    }

                    if (ascendingIsTheQuestion == true) {
                        nameDateList = nameDateList.OrderBy(s => s.second).ToList();
                    }
                    else {
                        nameDateList = nameDateList.OrderByDescending(s => s.second).ToList();
                    }

                    return nameDateList.GetRange(0, numberGetNameAndDatatime);
                }

            }
            String method = "public static  List<StringDatetime> getFileNameDateCreate(String sourceDirectory, int numberGetNameAndDatatime, bool ascendingIsTheQuestion) {" +
                      "sourceDirectory = " + sourceDirectory +
                     " numberGetNameAndDatatime =" + ascendingIsTheQuestion;
            Util.error(Util.ERRO_REGISTRY_LOG, method);

            return null;

        }

        

        private static string reverseString(string Word) {
            char[] arrayChar = Word.ToCharArray();
            Array.Reverse(arrayChar);
               return new String(arrayChar);         
        }

        private static string findExtension(string manipulationStringOrigem) {
            String manipulationString = manipulationStringOrigem;
            int firtOccurrence;          
            manipulationString = Intelligence.reverseString(manipulationString);
            firtOccurrence = manipulationString.IndexOf('.')+1;
            if (firtOccurrence < 0) {
                return string.Empty;
            }
            else {
                return reverseString(manipulationString.Substring(0, firtOccurrence));
              
            }

        }

        private static string removeExtension(string manipulationStringOrigem) {
            String manipulationString = manipulationStringOrigem;
            int firtOccurrence;
            manipulationString = Intelligence.reverseString(manipulationString);
            firtOccurrence = manipulationString.IndexOf('.') + 1;
            if (firtOccurrence < 0) {
                return string.Empty;
            }
            else {
                return reverseString(manipulationString.Substring(firtOccurrence, manipulationString.Length - firtOccurrence));

            }
        }

           public static string removeName(string manipulationStringOrigem) {
            String manipulationString = manipulationStringOrigem;
            int firtOccurrence;
            manipulationString = Intelligence.reverseString(manipulationString);
            firtOccurrence = manipulationString.IndexOf('\\') ;
            if (firtOccurrence < 0) {
                return string.Empty;
            }
            else {
                return reverseString(manipulationString.Substring(0,firtOccurrence));

            }           
        }

        public static string  copyDuplicateNewName ( string manipulationStringOrigem){
            return removeExtension(manipulationStringOrigem) + " - Copy-" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"+"\u20e0"+"fff ") + findExtension(manipulationStringOrigem);
    
         }
        private static byte[] checkFileOpen(string fileSeOpen) {
            try {
                return File.ReadAllBytes(fileSeOpen);
            }
            catch (Exception e) {
                String method = "private static byte[] checkFileOpen(string fileSeOpen) {" +
                " fileSeOpen = " + fileSeOpen;
                Util.error(Util.ERRO_REGISTRY_LOG, method, e.ToString());
                return null;
            }
        }
        public static int  FileEquals(string source, string destination) {
            /*
             * 0 = false;
             * 1 = true;
             * 3 = file is open;
             */
            
            byte[] fileSource = checkFileOpen(source);
            
            if (fileSource == null) {
                 File.Copy(source, Path.Combine (Util.FILE_LOCAL_TEMP, removeName (source)), true); // mecher nome final
                 fileSource = checkFileOpen(Path.Combine(Util.FILE_LOCAL_TEMP, removeName(source)));
                if (fileSource == null) {
                    return 0;
                }
            }

            byte[] fileDestination = checkFileOpen(destination);
                if (fileDestination == null) {
                    return 2; // file is open
                }
           

            if (fileSource.Length == fileDestination.Length) {
                for (int i = 0; i < fileSource.Length; i++) {
                    if (fileSource[i] != fileDestination[i]) {
                        return 0;
                    }
                }
                return 1;
            }
            return 0;
        }
    }
}
