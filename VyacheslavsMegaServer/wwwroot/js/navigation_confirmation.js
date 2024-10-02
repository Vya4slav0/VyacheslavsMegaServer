function confirmNavigation(event) {
    if (!confirm("Подтвердите удаление")) {
        event.preventDefault();
    }
}