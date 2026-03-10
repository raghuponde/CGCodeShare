
put this code in the body of html 
 
<form action="/cgi-bin/test.cgi" name="myForm"  
          onsubmit="return(validate());">
 <table cellspacing="2" cellpadding="2" border="1">
 <tr>
   <td align="right">Name</td>
   <td><input type="text" name="Name" /></td>
 </tr>
 <tr>
   <td align="right">EMail</td>
   <td><input type="text" name="EMail" /></td>
 </tr>
 <tr>
   <td align="right">Zip Code</td>
   <td><input type="text" name="Zip" /></td>
 </tr>
 <tr>
 <td align="right">Country</td>
 <td>
 <select name="Country">
   <option value="-1" selected>[choose yours]</option>
   <option value="1">USA</option>
   <option value="2">UK</option>
   <option value="3">INDIA</option>
 </select>
 </td>
 </tr>
 <tr>
   <td align="right"></td>
   <td><input type="submit" value="Submit" /></td>
 </tr>
 </table> </form>

           full code 
---------------------------
 <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script type="text/javascript">

        function validate() {
            if (document.myForm.Name.value == "") {
                alert("provide your name !");
                document.myForm.Name.focus();
                return false;
            }
            if (document.myForm.EMail.value == "") {
                alert("provie email address ");
                document.myForm.EMail.focus();
                return false;
            }

            if (document.myForm.Zip.value == "" || isNaN(document.myForm.Zip.value) || document.myForm.Zip.value.length != 5) {
                alert("provide zip code in format #####");
                document.myForm.Zip.focus();
                return false;
            }

            if (document.myForm.Country.value == "-1") {
                alert("provide country name");
                return false;
            }
            return true;
        }


    </script>
</head>

<body>
    <form action="/cgi-bin/test.cgi" name="myForm" onsubmit="return(validate());">
        <table cellspacing="2" cellpadding="2" border="1">
            <tr>
                <td align="right">Name</td>
                <td><input type="text" name="Name" required /></td>
            </tr>
            <tr>
                <td align="right">EMail</td>
                <td><input type="email" name="EMail" required /></td>
            </tr>
            <tr>
                <td align="right">Zip Code</td>
                <td><input type="text" name="Zip" required /></td>
            </tr>
            <tr>
                <td align="right">Country</td>
                <td>
                    <select name="Country">
                        <option value="-1" selected>[choose yours]</option>
                        <option value="1">USA</option>
                        <option value="2">UK</option>
                        <option value="3">INDIA</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right"></td>
                <td><input type="submit" value="Submit" /></td>
            </tr>
        </table>
    </form>

</body>

</html>

-----------------------------------------------------------------------------------
 Regular Expression in Javascript :
---------------------------------------------
Till now i have done validations to a form or a form fields using normal procedure like which is nothing but basic validations where we will see that mandatory fields are filled but as per the requirement i want to validate the input which i pass in 
the textbox then i will go regular expressions 


regular expressions are there in .net also and also in javascript 


pan card : five chaarcters ,4 numbers and one again alphabet 

some sites to refer :

https://regexhero.net/  

to test without program 

https://regexr.com/  go through this website throghly instructions

and in google type 

regex in javascript and check some tutorials as well and 
in youtube also u can check it by putting the same 


https://www.w3schools.com/jsref/jsref_obj_regexp.asp

https://www.programiz.com/javascript/regex

in youtube :


https://www.youtube.com/watch?v=nlGF-zh0fsg

 in the body paste this 

 <form>
        <table>
            <tr>
                <td>
                    <input type="text" placeholder="email" id="text" />
                </td>
                <td>
                    <div id="result">
    
                    </div>
                </td>
            </tr>
        </table>
        <br /><br />
        <button onclick="validate()" type="button">Submit</button>
    </form>
    
