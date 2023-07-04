// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).on('click', '.ajax-button', function (event) {
    event.preventDefault(); // Ngăn chặn hành vi mặc định của liên kết

    var url = $(this).data('url');
    var id = $(this).data('id');

    $.ajax({
        url: url + id,
        type: 'POST',
        success: function (data) {
            // Xử lý dữ liệu tải về từ máy chủ ở đây

            // Ẩn spinner container sau khi hoàn thành
            $('#spinner-container').hide();
        },
        error: function () {
            // Xử lý lỗi tại đây (nếu có)

            // Ẩn spinner container sau khi hoàn thành
            $('#spinner-container').hide();
        }
    });
});

function sendAjaxRequest(method, url, data) {
    $.ajax({
        url: url,
        type: method,
        withCredentials: false,
        crossDomain: true,
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (result) {
            // Xử lý kết quả nếu cần thiết
            document.getElementById("popup-form").reset();
            $('#spinner').hide();
            $('#exampleModal').modal('hide');
        },
        error: function (error) {
            // Xử lý lỗi nếu có
            console.error(error);
        }
    });
}
function appendDataToSelectCheckbox(data) {
    var selectElement = document.getElementById('inputCategory');

    // Iterate over the data and create option elements
    data.result.forEach(function (item) {
        var option = document.createElement('option');
        option.value = item.categoryId;
        option.textContent = item.categoryName;

        selectElement.appendChild(option);
    });
}