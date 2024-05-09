$(document).ready(function () {

})

$("#btnsubmit").click(function () {
    $.ajax({
        type:"GET",
        url: "https://localhost:7103/Home/Adduser",
        data: {
            username: $("#userid").val(),
            password: $("#userpsw").val()

        },
        success: function (data) {

        },
        error: function (error) {

        }
    })
})