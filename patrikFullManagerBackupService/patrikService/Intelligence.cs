using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using patrikDll;
using System.Diagnostics;
using static patrikDll.Util;
using static patrikDll.WorkerFile;

namespace patrikService {
    public class Intelligence {
        public enum searchDateFile {
            GetCreationTime,
            GetCreationTimeUtc,
            GetLastWriteTime,
            GetLastWriteTimeUtc
        };
        public static List<localTextDateTimeHashExtension> getFileNameDateCreateHash(String sourceDirectory, int typeSearchInSearchDateTimeFile = 0 /*default datetime creation*/, string extension = "*") {
            List<localTextDateTimeHashExtension> listLocalTextDateTimeHashExtension = new List<localTextDateTimeHashExtension>();
            if (extension != "*") {
                extension = "*." + extension;
            }
            try {
                if (Directory.Exists(sourceDirectory)) {
                    /*why?*/
                    //  if (numberGetNameAndDatatime > 0) {                    
                    string[] nameFiles = Directory.GetFiles(sourceDirectory, extension);            /*searh option possible solution for problens backup contabilidade*/
                    foreach (string s in nameFiles) {
                        Debug.WriteLine(s);
                        localTextDateTimeHashExtension helperNameDateTimeHash;
                        helperNameDateTimeHash.local = Path.GetDirectoryName(s);
                        helperNameDateTimeHash.text = Path.GetFileName(s);
                        helperNameDateTimeHash.hash = getSha1ToFile(Path.GetDirectoryName(s), helperNameDateTimeHash.text);
                        helperNameDateTimeHash.extension = Path.GetExtension(s);
                        switch (typeSearchInSearchDateTimeFile) {
                            case (int)searchDateFile.GetCreationTime:
                                helperNameDateTimeHash.dateAndHour = File.GetCreationTime(s);
                                break;
                            case (int)searchDateFile.GetCreationTimeUtc:
                                helperNameDateTimeHash.dateAndHour = File.GetCreationTimeUtc(s);
                                break;
                            case (int)searchDateFile.GetLastWriteTime:
                                helperNameDateTimeHash.dateAndHour = File.GetLastWriteTime(s);
                                break;
                            case (int)searchDateFile.GetLastWriteTimeUtc:
                                helperNameDateTimeHash.dateAndHour = File.GetLastWriteTimeUtc(s);
                                break;
                            default:
                                helperNameDateTimeHash.dateAndHour = File.GetCreationTime(s);
                                break;
                        }

                        listLocalTextDateTimeHashExtension.Add(helperNameDateTimeHash);
                        // }

                        /*  if (numberGetNameAndDatatime > listLocalTextDateTimeHashExtension.Count) {
                              numberGetNameAndDatatime = listLocalTextDateTimeHashExtension.Count;
                          }

                          if (ascendingIsTheQuestion == true) {
                              listLocalTextDateTimeHashExtension = listLocalTextDateTimeHashExtension.OrderBy(s => s.dateAndHour).ToList();
                          } else {
                              listLocalTextDateTimeHashExtension = listLocalTextDateTimeHashExtension.OrderByDescending(s => s.dateAndHour).ToList();
                          }*/

                        //   return listLocalTextDateTimeHashExtension.GetRange(0, numberGetNameAndDatatime);

                    }/*not backup after create treatment error*/

                    return listLocalTextDateTimeHashExtension;

                }/*after create treatment error*/
                String method = "public static  List<listLocalTextDateTimeHashExtension> getFileNameDateCreateHash(String sourceDirectory, int numberGetNameAndDatatime, bool ascendingIsTheQuestion) {" +
                          "sourceDirectory = " + sourceDirectory +
                         " numberGetNameAndDatatime =" + "ascendingIsTheQuestion";
                Util.error(Util.ERRO_REGISTRY_LOG, method);

            } catch (Exception erro) {
                Console.WriteLine(erro.ToString());
            }

            return null;

        }



        /*function for restriction days not useful*/
        public static int calculeAmountDaysUseful(int days) {

            return days;
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
            firtOccurrence = manipulationString.IndexOf('.') + 1;
            if (firtOccurrence < 0) {
                return string.Empty;
            } else {
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
            } else {
                return reverseString(manipulationString.Substring(firtOccurrence, manipulationString.Length - firtOccurrence));

            }
        }

        public static string removeName(string manipulationStringOrigem) {
            String manipulationString = manipulationStringOrigem;
            int firtOccurrence;
            manipulationString = Intelligence.reverseString(manipulationString);
            firtOccurrence = manipulationString.IndexOf('\\');
            if (firtOccurrence < 0) {
                return string.Empty;
            } else {
                return reverseString(manipulationString.Substring(0, firtOccurrence));

            }
        }

        public static string copyDuplicateNewName(string manipulationStringOrigem) {
            return removeExtension(manipulationStringOrigem) + " - Copy-" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss" + "\u20e0" + "fff ") + findExtension(manipulationStringOrigem);

        }
        private static byte[] checkFileOpen(string fileSeOpen) {
            try {
                return File.ReadAllBytes(fileSeOpen);
            } catch (Exception e) {
                String method = "private static byte[] checkFileOpen(string fileSeOpen) {" +
                " fileSeOpen = " + fileSeOpen;
                Util.error(Util.ERRO_REGISTRY_LOG, method, e.ToString());
                return null;
            }
        }
        public static int FileEquals(string source, string destination) {
            /*
             * 0 = false;
             * 1 = true;
             * 3 = file is open;
             */

            byte[] fileSource = checkFileOpen(source);

            if (fileSource == null) {
                File.Copy(source, Path.Combine(Util.FILE_LOCAL_TEMP, removeName(source)), true); // mecher nome final
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
