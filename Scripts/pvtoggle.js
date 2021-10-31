var rendered = "login";
$("#LoginButton").click(function () {

	if (rendered != "login") {
		$.ajax({
			url: '/Home/Login',
			dataType: 'html',
			success: function (data) {
				$('#content').html(data);
				rendered = "login";
			}
		});
	}
});
$("#RegButton").click(function () {

	if (rendered != "register") {

		$.ajax({
			url: '/Home/Register',
			dataType: 'html',
			success: function (data) {
				$('#content').html(data);
				rendered = "register";
			}
		});
	}
});