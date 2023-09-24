function displayErrorMessage(err) {
    let jsonError = err.responseJSON

    if (jsonError) {
        if (Array.isArray(jsonError)) {
            for (let a = 0; a < jsonError.length; a++) {
                const item = jsonError[a];
                const listItem = document.createElement('li');
                listItem.innerHTML = item;

                errorList.appendChild(listItem);
            }
        }
    } else {
        errorMessage.innerHTML = err.responseText;
    }
}