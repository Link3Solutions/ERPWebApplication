﻿// xtreeView JScript File



var ie5=document.all&&document.getElementById
var ns6=document.getElementById&&!document.all
if (ie5||ns6)
var menuobj=document.getElementById("Panel2")

function showmenuie5(e){
//Find out how close the mouse is to the corner of the window
var rightedge=ie5? document.body.clientWidth-event.clientX : window.innerWidth-e.clientX
var bottomedge=ie5? document.body.clientHeight-event.clientY : window.innerHeight-e.clientY

//if the horizontal distance isn't enough to accomodate the width of the context menu
if (rightedge<menuobj.offsetWidth)
//move the horizontal position of the menu to the left by it's width
menuobj.style.left=ie5? document.body.scrollLeft+event.clientX-menuobj.offsetWidth : window.pageXOffset+e.clientX-menuobj.offsetWidth
else
//position the horizontal position of the menu where the mouse was clicked
menuobj.style.left=ie5? document.body.scrollLeft+event.clientX : window.pageXOffset+e.clientX

//same concept with the vertical position
if (bottomedge<menuobj.offsetHeight)
menuobj.style.top=ie5? document.body.scrollTop+event.clientY-menuobj.offsetHeight : window.pageYOffset+e.clientY-menuobj.offsetHeight
else
menuobj.style.top=ie5? document.body.scrollTop+event.clientY : window.pageYOffset+e.clientY

if(ie5)
    window.event.cancelBubble = true;
else if(ns6)
    e.stopPropagation();

menuobj.style.visibility="visible"

    
return false
}

function hidemenuie5(e){
menuobj.style.visibility="hidden"
}

function highlightie5(e){
var firingobj=ie5? event.srcElement : e.target
if (firingobj.className=="menuitems"||ns6&&firingobj.parentNode.className=="menuitems"){
if (ns6&&firingobj.parentNode.className=="menuitems") 
firingobj=firingobj.parentNode //up one node

firingobj.style.backgroundColor="highlight"

}
}

function lowlightie5(e){
var firingobj=ie5? event.srcElement : e.target
if (firingobj.className=="menuitems"||ns6&&firingobj.parentNode.className=="menuitems"){
if (ns6&&firingobj.parentNode.className=="menuitems") 
firingobj=firingobj.parentNode //up one node

firingobj.style.backgroundColor=""


window.status=''
}
}

function jumptoie5(e){
var firingobj=ie5? event.srcElement : e.target
if (firingobj.className=="menuitems"||ns6&&firingobj.parentNode.className=="menuitems"){
if (ns6&&firingobj.parentNode.className=="menuitems") 
var firingobj2=firingobj.parentNode
// the click can be controlled by firingobj
// if the click was generated by the div tag enclosing the link buttons
//then the value of firingobj=htmlDivElement el
// else if the click was generated by the linkbutton
// then the value of firingobj will be href of the link button and the value of firingobj2 will be htmlDivElement
// the code for controlling the clciks goes here

}
}

if (ie5||ns6){
menuobj.style.display=''
document.onclick=hidemenuie5

}

