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

function clearMessages() {
    errorList.innerHTML = '';
    successMessage.innerHTML = '';
    errorMessage.innerHTML = '';
}

function clearFormValues(formId) {
    const form = document.getElementById(formId);
    const inputElements = form.getElementsByTagName('input');

    for (let i = 0; i < inputElements.length; i++) {
        let item = inputElements[i];
        item.value = '';
    }
}