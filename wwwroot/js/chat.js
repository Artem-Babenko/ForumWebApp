
export function chatElements() {

    const chatElements = [];

    // Header
    const chatHeader = jQuery('<div>');
    chatHeader.addClass('chat-header');

    chatElements.push(chatHeader);

    // Main
    const chatMain = jQuery('<div>');
    chatMain.addClass('chat-main');

    chatElements.push(chatMain);

    // Footer
    const chatFooter = jQuery('<div>');
    chatFooter.addClass('chat-footer');

    chatElements.push(chatFooter);

    return chatElements;
}
