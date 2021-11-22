$(document).ready(function() {
	$.getJSON("../Items.json", function(data) {
		var ul = eachChildren(data);
		$('#content').append(ul);
		
	}).fail(function(){
		alert("Fichero no econtrado");
	});	
});

function eachChildren(data) {
	var ul = $('<ul>');
	data.forEach(function(val, index) {	
	var li = $('<li>');	
		var span = $('<span>').text(val.Name);
		li.append(span);
		ul.append(li);
		if (val.Children.length > 0) {			
			var ul_child = eachChildren(val.Children)
			li.append(ul_child);
		}		
	});	
	return ul;
}
