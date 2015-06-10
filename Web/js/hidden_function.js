// JavaScript Document
/*function enableTooltips(id){ 
var links,i,h; 
if(!document.getElementById || !document.getElementsByTagName) return; 
AddCss(); 
h=document.createElement("span"); 
h.id="btc"; 
h.setAttribute("id","btc"); 
h.style.position="absolute"; 
document.getElementsByTagName("body")[0].appendChild(h); 
if(id==null) links=document.getElementsByTagName("a"); 
else links=document.getElementById(id).getElementsByTagName("a"); 
for(i=0;i<links.length;i++){ 
    Prepare(links[i]); 
    } 
} 
function Prepare(el){ 
var tooltip,t,b,s,l; 
t=el.getAttribute("title"); 
if(t==null || t.length==0) t="link:"; 
el.removeAttribute("title"); 
tooltip=CreateEl("span","tooltip"); 
s=CreateEl("span","top"); 
s.appendChild(document.createTextNode(t)); 
tooltip.appendChild(s); 
b=CreateEl("b","bottom"); 
l=el.getAttribute("href"); 
if(l.length>30) l=l.substr(0,27)+"..."; 
b.appendChild(document.createTextNode(l)); 
tooltip.appendChild(b); 
setOpacity(tooltip); 
el.tooltip=tooltip; 
el.onmouseover=showTooltip; 
el.onmouseout=hideTooltip; 
el.onmousemove=Locate; 
} 
function showTooltip(e){ 
document.getElementById("btc").appendChild(this.tooltip); 
Locate(e); 
} 
function hideTooltip(e){ 
var d=document.getElementById("btc"); 
if(d.childNodes.length>0) d.removeChild(d.firstChild); 
} 
function setOpacity(el){ 
el.style.filter="alpha(opacity:95)"; 
el.style.KHTMLOpacity="0.95"; 
el.style.MozOpacity="0.95"; 
el.style.opacity="0.95"; 
} 
function CreateEl(t,c){ 
var x=document.createElement(t); 
x.className=c; 
x.style.display="block"; 
return(x); 
} 
/*function AddCss(){ 
var l=CreateEl("link"); 
l.setAttribute("type","text/css"); 
l.setAttribute("rel","stylesheet"); 
l.setAttribute("href","http://web-graphics.com/mtarchive/bt.css"); 
l.setAttribute("media","screen"); 
document.getElementsByTagName("head")[0].appendChild(l); 
} */
