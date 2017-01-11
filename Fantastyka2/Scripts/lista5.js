var globalVariable = 0;

var book1Function = function () {
  document.writeln("&quotPomnik Cesarzowej Achai&quot - Andrzej Ziemiański 2012");
}

window.addEventListener("load", function() {
    document.getElementById("book2").onclick = function() { book2Function() };

    document.getElementById("book4").onclick = function() { book4Function() };

    document.getElementById("book5").onclick = function() { book5Function() };

    document.getElementById("book6").onclick = function() { book6Function() };

    document.getElementById("book7").onclick = function() { bookClickFunction(this.id) };

    document.getElementById("book8").onclick = function() { bookClickFunction(this.id) };

    document.getElementById("book9").onclick = function() { book9Function() };

    document.getElementById("book10").onclick = function() { book10Function() };
 },false);

window.addEventListener("click",
    function() {
        globalVariable++;
        document.getElementById("pageCount").innerText = "Licznik kliknięć: " + globalVariable;
    },
    true);

 var book2Function = function() {
    document.writeln("&quotCzas pogardy&quot - Andrzej Sapkowski 1995");
    var btn = document.createElement("BUTTON");
    var t = document.createTextNode("Wróć");
    btn.appendChild(t);
    
    btn.addEventListener('click', function() {
      location.reload();
    }, false);

    document.body.appendChild(btn);  
 }

  var book4Function = function() {
    var twojGlos = prompt("Podaj tytuł swojej ulubionej książki", "Pułapka Tesli");
    if (twojGlos != null) {
      confirm("Twoja ulubiona książka to: " + twojGlos);
    } else {
      alert("Nie podałeś swojej ulubionej książki");
    }
 } 

 var book5Function = function() {
    document.getElementById("ParagrafTitle").innerHTML = "Paragraph changed!";
    if(isEven(globalVariable)){
      document.getElementById("book5").src="../Images/terryPratchett.jpg";
    } else {
        document.getElementById("book5").src = "../Images/w120_u90(3).jpg";
    }    
 }

function isEven(n) {
   return n % 2 == 0;
}

 var book6Function = function() {
    var zwiekszLicznik = prompt("Podaj liczbę lajków dla książki 'Świat finansjery'", "10");
    if (!isNaN(parseInt(zwiekszLicznik))) {
      globalVariable += parseInt(zwiekszLicznik) - 1;
    }else{
      globalVariable = globalVariable;
    }
    document.getElementById("pageCount").innerText = "Licznik kliknięć: "+ globalVariable;
 } 


var bookClickFunction = function(id) {
  var bookId = id;
  switch (bookId) {
    case 'book7':
        alert('Wybrałeś - Chłopcy. Będziesz to prać! ');
        break;
    case 'book8':
        alert('Wybrałeś - Kłamca 2');
        break;
    default:
        console.log('Nie wiem co to za książka');
  }
}

var book9Function = function() {
  var x=1;
    do{
      var a = Math.random()*(20 - 10) + 10;
      console.log(a);
      console.log(Math.floor(a));      
      x++;
    }while(x<4)
    alert('Sprawdź konsolę(f12)');
 }

 var book10Function = function() {
  var iloscLiczb = prompt("Podaj swoją ocenę książki:", "9.01");
     var maxNumber = parseFloat(iloscLiczb);
  for(var x=0;x<maxNumber;x++){
    alert("Twoja ocena wzrosła:" + x);
  }
 }