document.addEventListener("keydown", function (event) {
    let delta = { top: 0, left: 0 };

    switch (event.key) {
        case "ArrowUp":
            delta.top = -1;
            break;
        case "ArrowDown":
            delta.top = 1;
            break;
        case "ArrowLeft":
            delta.left = -1;
            break;
        case "ArrowRight":
            delta.left = 1;
            break;
        default:
            return; // Игнорируем остальные клавиши
    }

    fetch('/Game/MoveTank', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(delta)
    }).then(response => {
        if (response.ok) {
            location.reload(); // Обновляем карту после перемещения
        }
    });
});
