var listaItems = document.getElementById("lista");
var btnAdd = document.getElementById("btn-agregar")
var btnRmv = document.getElementById("btn-remover")
var cbList  = document.querySelectorAll("cb");
function añadirTarea(){
    var nuevaTarea = document.getElementById("input-agregar").value;
    var li = document.createElement("li");
    var cb  = document.createElement("input");
        cb.setAttribute("type", "checkbox");
        cb.setAttribute("class", "cb");
        if(nuevaTarea !== ""){
            li.textContent = nuevaTarea;
            listaItems.appendChild(li);
            listaItems.appendChild(cb);
} else{
    alert("escribe algo");
    }


    document.getElementById("input-agregar").value = "";
    var cbLast = cb[cb.length-1];
}


function removerTarea(){
    var items = document.querySelectorAll("#lista li")
    var lastItem = items[items.length - 1];
    lastItem.remove();

}

cbLast.addEventListener("checked", removerTarea);
btnAdd.addEventListener("click", añadirTarea);

btnRmv.addEventListener("click", removerTarea);



/*
const listaItems = document.querySelectorAll("li");

function toggleDone(e){
    if(!e.target.className){
        e.target.className = "done";

    }else{
        e.target.className = "";
    }
}
    listaItems.forEach((item) => {  
        item.addEventListener("click", toggleDone);
    }); 

const myh1 = document.querySelector("h1");
const input = document.querySelector("input");

input.addEventListener("change", (e) => {
    myh1.textContent = e.target.value;
});*/