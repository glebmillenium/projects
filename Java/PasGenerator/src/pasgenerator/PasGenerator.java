/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pasgenerator;

import java.io.*;
import java.util.*;

/**
 *
 * @author
 */
public class PasGenerator {
    public static Integer Result = 0;                                   //?????? ??????? ResultMass
    public static String str;
    public static Integer dlinnapass = 0;                                   //?????? ??????
    
    //public static char [] ResultMass = new char[Result];                //???????
        public static char [] massNum = new char[10];
        public static char [] massSLat = new char[26];
        public static char [] massBLat = new char[26];
        public static String [] massSkirril = new String[33];
        public static String [] massBkirril = new String[33];
        public static char [] massSymb = new char[26];

    public static void main(String[] args) {
    }

    public static void writeStringToFile(String fileName, String str) throws IOException {
        FileWriter fw = new FileWriter(new File(fileName), true);
        try {
            String[] arrayWords = str.split("s+");
            for (String s : arrayWords) {
                fw.write(s + "\r\n");
            }
            fw.close();
        } catch (Exception e) {
        }
    }
    
    public static char[] massNumbers(){                 //0-9
        char o = 48;
        for (int i=0; i<10; i++){
            massNum[i] = (char) ((char) o + i);
        }
        return massNum;
    }
    
    public static char[] massSLatinica(){               //a-z
        char a = 97;
        for (int i=0; i<26; i++){
            massSLat[i] = (char) ((char) a + i);
        }
        return massSLat;
    }
    
        public static char[] massBLatinica(){           //A-Z
        char A = 65;
        for (int i=0; i<26; i++){
            massBLat[i] = (char) ((char) A + i);
        }
        return massBLat;
    }
    
        public static String[] massSKirilica(){           //a-?
        massSkirril[0] = "а";   massSkirril[11] = "к";    massSkirril[22] = "х";
        massSkirril[1] = "б";   massSkirril[12] = "л";    massSkirril[23] = "ц";
        massSkirril[2] = "в";   massSkirril[13] = "м";    massSkirril[24] = "ч";
        massSkirril[3] = "г";   massSkirril[14] = "н";    massSkirril[25] = "ш";
        massSkirril[4] = "д";   massSkirril[15] = "о";    massSkirril[26] = "щ";
        massSkirril[5] = "е";   massSkirril[16] = "п";    massSkirril[27] = "ъ";
        massSkirril[6] = "ё";   massSkirril[17] = "р";    massSkirril[28] = "ы";
        massSkirril[7] = "ж";   massSkirril[18] = "с";    massSkirril[29] = "ь";
        massSkirril[8] = "з";   massSkirril[19] = "т";    massSkirril[30] = "э";
        massSkirril[9] = "и";   massSkirril[20] = "у";    massSkirril[31] = "ю";
        massSkirril[10] = "й";  massSkirril[21] = "ф";    massSkirril[32] = "я";
        return massSkirril;
    }
/*        public static String massSKirilica(){           //a-?
        char a = 224;
        for (int i=0; i<33; i++){
            massSkirril[i] = (char) ((char) a + i);
        }
        StringBuilder sb = new StringBuilder(8);
        for (int r=0;r<33;r++){
        str = sb.append(massSkirril[r]).toString();
        }                                 
        return str;
    }*/
        
        public static String[] massBKirilica(){           //?-?
        massBkirril[0] = "А";   massBkirril[11] = "К";    massBkirril[22] = "Х";
        massBkirril[1] = "Б";   massBkirril[12] = "Л";    massBkirril[23] = "Ц";
        massBkirril[2] = "В";   massBkirril[13] = "М";    massBkirril[24] = "Ч";
        massBkirril[3] = "Г";   massBkirril[14] = "Н";    massBkirril[25] = "Ш";
        massBkirril[4] = "Д";   massBkirril[15] = "О";    massBkirril[26] = "Щ";
        massBkirril[5] = "Е";   massBkirril[16] = "П";    massBkirril[27] = "Ъ";
        massBkirril[6] = "Ё";   massBkirril[17] = "Р";    massBkirril[28] = "Ы";
        massBkirril[7] = "Ж";   massBkirril[18] = "С";    massBkirril[29] = "Ь";
        massBkirril[8] = "З";   massBkirril[19] = "Т";    massBkirril[30] = "Э";
        massBkirril[9] = "И";   massBkirril[20] = "У";    massBkirril[31] = "Ю";
        massBkirril[10] = "Й";  massBkirril[21] = "Ф";    massBkirril[32] = "Я";
        return massBkirril;
    }
        
        public static char[] massSymbols(){             //!"?;%:...
        char aA = 33;
        for (int i=0; i<15; i++){
            massSymb[i] = (char) ((char) aA + i);
        }
        char aB = 43;
        for (int i=15; i<22; i++){
            massSymb[i] = (char) ((char) aB + i);
        }
        char aC = 101;
        for (int i=22; i<26; i++){
            massSymb[i] = (char) ((char) aC + i);
        }
        return massSymb;
    }

}