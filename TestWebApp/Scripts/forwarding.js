$(document).ready(function() {

    var dataSource = [];

    $(function() {
        $("[id^='date']").datetimepicker({
            locale: "ru",
            showClose: true,
            format: "DD.MM.YYYY"
        });
    });
    
    $("[class='glyphicon glyphicon-remove']").click(function () {
        var control = $(this).closest("div").find("input.typeahead");
        control.val("");
        control.removeAttr("disabled");
        $("#hidden" + control[0].id).val("");
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
            $(this.$element[0]).attr("disabled", "disabled");
            return item;
        }
    });

});