function mySearch() {
	var request = document.getElementById('mysearch');
	var table = document.getElementById('mytable');
	var reg = new RegExp(request.value, 'i');
	var flag = false;
	for (var i = 1; i < table.rows.length; i++) {
		flag = false;
		for (var j = table.rows[i].cells.length - 1; j >= 0; j--) {
			flag = reg.test(table.rows[i].cells[j].innerHTML);
			if (flag) break;
		}
		if (flag) {
			table.rows[i].style.display = "";
		}
		else {
			table.rows[i].style.display = "none";
		}
	}
}