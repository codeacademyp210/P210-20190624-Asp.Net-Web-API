var xhttp = new XMLHttpRequest();

xhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
       // Typical action to be performed when the document is ready:
    //    document.getElementById("demo").innerHTML = xhttp.responseText;
       console.log(xhttp.responseText)
    }
};
xhttp.open("GET", "http://localhost:60284/api/user", true);


xhttp.setRequestHeader("Content-Type","application/json");
xhttp.setRequestHeader("token", "AJ/w7fqVWDIStchXS7x8tVemEjuIDghtUvmJUfcsYOd66+/6cJdINK6l99xH2hhBww==");


xhttp.send();