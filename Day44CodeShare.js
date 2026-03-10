
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

-------------------complte code -----
 <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script>
        function validate() {
            var mail = document.getElementById("text").value;
            var regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/
            if (regex.test(mail)) {
                document.getElementById("result").innerHTML = "valid email id ";
                document.getElementById("result").style.color = "green";
            }
            else {
                document.getElementById("result").innerHTML = "Invalid email id ";
                document.getElementById("result").style.color = "red";
            }

        }
    </script>
</head>

<body>
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
</body>

</html>
    
-----------------onlyjsdemo1.js-----------------
 function test() {
    console.log("Hello world");
}

function test2(num1, num2) {
    return (num1 + num2);
}


test();
let sum = test2(12, 45);
console.log(sum);
//using arrow functions
const testme = () => console.log("Hello world2");
let sum2 = (n1, n2) => (n1 + n2);
testme();
console.log(sum2(12, 56));

//variable.map(element)=>print(element)

var arr = [10, 20, 30, 40, 50];
arr.map((ele) => console.log(ele));

// example 2 
const numbers = [1, 2, 3, 4, 5];
const squares = numbers.map(value => value * value);
console.log(squares);

const people = [{ id: 1, name: "felpie", country: "USA" },
{ id: 2, name: "mohan", country: "INDIA" },
{ id: 3, name: "jagdish", country: "SRILanka" }
]

const names = people.map(p => p.name);
console.log(names);

// filter function
//array.filter(ele=>(condition))

var filtered = numbers.filter(x => x > 3);
console.log(filtered);

now add one file Arraysinjs.html and in body paste this code 
----------------------------------------------------------
 <p id="demo" style="background:rgb(177, 113, 35);width:90%;height:100px;
                font-size:large;font-weight:900px ;">
    
    </p>

final code(still code will be written)
--------------
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <p id="demo" style="background:rgb(177, 113, 35);width:90%;height:100px;
                    font-size:large;font-weight:900px ;">

    </p>
    <script>
        //difference between var,let and const 
        var kk = "hai";
        kk = "hi"// can reassign
        {
            var kk = "hello";
        }
        console.log(kk);

        let kk1 = "hai";
        kk1 = "hi"// can reassign
        {
            let kk1 = "hello"
        }
        console.log(kk1);

        const kk2 = "hai";
        // kk2 = "hi";// u cannot assign here const value in run time it will give error 
        console.log(kk2);

        let cars = ["BMW", "Hyndai", "TATA", "Skoda"];

        document.getElementById("demo").innerHTML = cars;

        // first car 

        let firstcar = cars[0];

        document.getElementById("demo").innerHTML = firstcar;

        //no elements in array

        let length = cars.length;

        document.getElementById("demo").innerHTML = length;

        // last car

        let lastcar = cars[cars.length - 1]

        document.getElementById("demo").innerHTML = lastcar;

        //loop over the array and put it i p tag 

        var str = "";
        for (var i = 0; i < cars.length; i++) {
            str = str + (i + 1) + ":" + cars[i] + "<br/>";
        }
        document.getElementById("demo").innerHTML = str;

        // using for each loop 

        cars.forEach((item, index, array) => { console.log(index + 1) + "----->" + item });

        // removing last car 

        let lastcar1 = cars.pop();

        document.getElementById("demo").innerHTML = lastcar1;

        // adding at the last 

        let lastcar2 = cars.push("AUDI");

        document.getElementById("demo").innerHTML = cars;

        //remoing first car

        let firstcar1 = cars.shift();
        document.getElementById("demo").innerHTML = firstcar1;

        //adding at the begining 
        let newfirstcar = cars.unshift("TOYATO");
        document.getElementById("demo").innerHTML = cars;

        let bikes = ["Gixxer", "Yamaha", "Apache"];

        let vahicles = cars.concat(bikes);

        document.getElementById("demo").innerHTML = vahicles;

        // printing using map function in js

        // Use map to create an HTML list
        document.getElementById("demo").innerHTML = cars.map(car => `<li>${car}</li>`).join('');

        let num1 = [2, 3, 4, 5, 6];
        let num2 = num1.map(x => x * 2);
        document.getElementById("demo").innerHTML = num2;
        //or
        function multiply(value) {
            return value * 3;
        }

        let num3 = num1.map(multiply);
        document.getElementById("demo").innerHTML = num3;

        let num4 = num1.filter(x => x > 4);
        document.getElementById("demo").innerHTML = num4;

        //or

        function comp(value) {
            return value > 4;
        }

        let num5 = num1.filter(comp);

        document.getElementById("demo").innerHTML = num5;

        //reduce will reduce the array to single value 

        function sum(total, value) {
            return total + value;
        }

        let num6 = num1.reduce(sum);
        document.getElementById("demo").innerHTML = num6;
        //or

        let num7 = num1.reduce((total, value) => total + value);

        document.getElementById("demo").innerHTML = num7;

    </script>
</body>

</html>


---- go to drive and download one  folder with name DOMDemo in drive of capgminenin


