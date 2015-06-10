function hideAll(str)
{
var sn="glxxd";
var k;
for(var i=0;i<20;i++)
{
   k = sn+i;
   if(str == k)
   {
    if(document.getElementById(str).style.display == "none")
    {
     document.getElementById(str).style.display='';
    }
	else
    {
     document.getElementById(str).style.display='none';
    }
   }else
   {
    document.getElementById(k).style.display='none';
   }
}
}// JavaScript Document