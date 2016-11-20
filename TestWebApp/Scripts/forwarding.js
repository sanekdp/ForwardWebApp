$(document).ready(function () {

    var dataSource = [];

    $(function () {
        $("[id^='date']").datetimepicker({
            locale: "ru",
            showClose: true,
            format : "DD.MM.YYYY"
        });
    });

    $.ajax({
        url: "/Home/Employees",
        type: "POST",
        dataType: "JSON",
        async : false,
        success: function (data) {
            dataSource = data;
        },
        error : function(data) {
            alert("Error");
        }
    });

    $("#custom-templates .typeahead").typeahead({
        name: "Employees",
        minLength : 2,
        source: dataSource,
        displayText: function(item) {
             return item.Name;
        },
        matcher: function (item) {
            return ~item.Name.toLowerCase().indexOf(this.query.toLowerCase()) ||
                   ~item.Email.toLowerCase().indexOf(this.query.toLowerCase());
        },
        highlighter: function (name, item) {
            return "<div><strong>" + item.Name +"</strong></br>" + item.Email +"</div>";
        },
        updater: function (item) {
            $("#hidden" + this.$element[0].id).val(item.Email);
            return item;
        }
    });

});