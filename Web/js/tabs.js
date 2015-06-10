function setTab(name,cursel,n){
for(i=1;i<=n;i++){
var menu=document.getElementById(name+i);
var con=document.getElementById("con_"+name+"_"+i);
menu.className=i==cursel?"tab"+name+"-on":"";
con.style.display=i==cursel?"block":"none";
}
}

function setTabdis(name,cursel,n){
for(i=1;i<=n;i++){
var menu=document.getElementById(name+i);
var con=document.getElementById("con_"+name+"_"+i);
menu.className=i==cursel?"tab"+name+"-on":"";
con.className=i==cursel?"":"disn";
}
}