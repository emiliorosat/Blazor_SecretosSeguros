'use strict'

function ShowToast(){
    $('.toast').toast('show')
}

function SaveToken(token){
    localStorage.setItem("token", token)
}

function ReadToken(){
    let token = localStorage.getItem("token")
    console.log("call")
    return token != null ? token : ""
}

function DeleteToken(){
    localStorage.removeItem("token")
}