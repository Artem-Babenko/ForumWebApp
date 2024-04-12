import { chatElements } from "./chat.js"
import { chatListItems } from "./chatList.js";

const chatListContainer = $('#chatList');

$(window).on('load', function () {

    // Nav
    //const chatListContainer = jQuery('#chatList');
    //chatListContainer.add(chatListItems());
    setChatList();
    initSearch();

    // Chat
    //const chatContainer = jQuery('#chatContainer');
    //chatContainer.add(chatElements());

    // Menu

});

function initSearch() {
    const searchInput = $('#search');
    let timeoutId;

    // Обробка введення тексту у пошук
    searchInput.on('input', function () {
        const inputedValue = searchInput.val();

        if (inputedValue.trim() === '' || inputedValue.length < 3) {
            setChatList();
            return;
        }

        clearTimeout(timeoutId);

        // Якщо нічого не вводити секуду
        // буде відправлений запит на сервер
        timeoutId = setTimeout(function () {

            // запит на отримання даних
            $.ajax({
                url: `/chat/search?value=${inputedValue}`,
                method: 'get',
                dataType: 'json',
                success: function (data) {
                    chatListContainer.text("");
                    setSearchResult(data);
                },
                error: function (xhr, exception) {
                    if (xhr.status === 500) {
                        alert("Server error");
                        console.log(exception);
                    }
                }
            })

        }, 300);
    });
}

function setChatList() {
    const chatListContainer = $('#chatList');

}

function setSearchResult(data) {
    data.users.forEach(user => {
        const userSymbols = user.name.charAt(0).toUpperCase() + user.surname.charAt(0).toUpperCase();
        chatListContainer.append(
            `<div class="chat-item">
                <div class="icon-container">
                    <p class="icon">${userSymbols}</p>
                    <p class="status active"></p>
                </div>
                <div class="info">
                    <div class="head">
                        <p class="name">${user.name} ${user.surname}</p>
                    </div>
                    <p class="user-id">ID: ${user.id}</p>
                </div>
            </div>`
        );
    });
}