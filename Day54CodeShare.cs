create one folder in day54 with name jquerydemos2 and add one html file into it with name dollareachdemos.html and paste the below code into it 

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js">

    </script>
    <script type="text/javascript" language="Javascript">
         var friends = ["sunitha", "mahesh", "kiran", "sanmay"];

            var objs = [{ "name": "sita", "age": "23" }, { "name": "rajesh", "age": "55" }, { "name": "kiran", "age": "22" },
            { "name": "praveen", "age": "27" }]

            $(document).ready();
        </script>
</head>
<body>
    <ul>
        <li>US</li>
        <li>India</li>
        <li>UK</li>
        <li>Canada</li>
        <li>Australia</li>
    </ul>
    
    <div id="divresult" style="background-color: yellow;">
    
     
    
    </div> 
</body>
</html>

updated code 
--------------
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js">

    </script>
    <script type="text/javascript" language="Javascript">
        var friends = ["sunitha", "mahesh", "kiran", "sanmay"];

        var objs = [{ "name": "sita", "age": "23" }, { "name": "rajesh", "age": "55" }, { "name": "kiran", "age": "22" },
        { "name": "praveen", "age": "27" }]

        $(document).ready(

            function () {

                $.each(friends, function (index, value) {
                    console.log((index + 1) + ":----->" + value);

                })

                $.each(objs, function (index, value) {
                    console.log((index + 1) + ":" + value.name + " is having age " + value.age);
                })

                console.log("I want to iterate list")
                $("li").each(function (index, element) {
                    alert((index + 1) + ": " + $(element).text())
                })

                console.log("I want to iterate using reference")

                $("li").each(function (index) {
                    alert((index + 1) + ":" + $(this).text());
                })

                console.log("iterating collection and puttin in div tage result ");

                var results = "";
                $.each(friends, function (index, value) {

                    results += "<br/><li>" + value + "</li>"
                })
                $("#divresult").html(results);



            }






        );
    </script>
</head>

<body>
    <ul>
        <li>US</li>
        <li>India</li>
        <li>UK</li>
        <li>Canada</li>
        <li>Australia</li>
    </ul>

    <div id="divresult" style="background-color: yellow;">



    </div>
</body>

</html>

go to this url https://jsonplaceholder.typicode.com/users and check the data i need to read the data present at this url and display it  in table


so paste the below code like this for in the new file ajaxdemo1.html 

<!DOCTYPE html>
<html>

<head>
    <title>jQuery Ajax Table Example</title>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js">

    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready()
        
    </script>
</head>

<body>

    <h2>User Data</h2>
    <table border="1" id="userTable">
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Email</th>
            </tr>
        </thead>
        <tbody>
            <!-- Data will be loaded here -->
        </tbody>
    </table>


</body>

</html>





