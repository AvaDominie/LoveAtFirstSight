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

export const CreateFoster = (animalId, userId) => {
    return fetch(`${_apiUrl}/addAdoption/${userId}/${animalId}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({}),
    }).then((res) => res);
};
