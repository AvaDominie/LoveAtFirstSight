const _apiUrl = "/api/adopt";


export const createAdoption = (animalId, userId) => {
    return fetch(`${_apiUrl}/addAdoption/${userId}/${animalId}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({}),
    }).then((res) => res);
};

export const createFoster = (animalId, userId) => {
    return fetch(`${_apiUrl}/addFoster/${userId}/${animalId}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({}),
    }).then((res) => res);
};


export const updateUnFoster = (userId, animalId) => {
    return fetch(`${_apiUrl}/updateUnfosterAdopt/${userId}/${animalId}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({}),
    }).then((res) => res);
};


export const deleteFoster = (userId, animalId) => {
    return fetch(`${_apiUrl}/deleteAdopt/${userId}/${animalId}`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({}),
    }).then((res) => res);
};