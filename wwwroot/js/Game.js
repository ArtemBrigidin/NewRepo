ResizeDiv(".GameField", ".GameFightField")
$("#NewGameButton").on("click", StartGameBtnClicked)

function StartGameBtnClicked(event) {
    $.post("/StartGame")
        .done(function (data) {
            console.log("Ответ от сервера:", data);
            $(".GameField").remove(); 
            $(".GameContainer").html(data); 
            $("#NewGameButton").off("click").on("click", StartGameBtnClicked);
        })
        .fail(function (xhr) {
            console.error("Ошибка выполнения POST /StartGame", xhr);
            alert("Не удалось начать игру. Проверьте настройки сервера.");
        });
}


function ResizeDiv(sourceSelector, targetSelector) {
    const width = $(sourceSelector).css("width")
    const height = $(sourceSelector).css("height")

    $(targetSelector).css("width", width)
    $(targetSelector).css("height", height)
}