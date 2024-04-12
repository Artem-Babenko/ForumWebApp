import { chatElements } from "./chat.js"
import { chatListItems } from "./chatList.js";

jQuery(document).on('load', function () {

    // Nav
    const chatListContainer = jQuery('#chatList');
    chatListContainer.add(chatListItems());

    // Chat
    const chatContainer = jQuery('#chatContainer');
    chatContainer.add(chatElements());

    // Menu

});
