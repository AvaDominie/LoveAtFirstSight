const _apiUrl = "/api/breed";

export const getDogBreeds = () => {
    return fetch(`${_apiUrl}/dogs`).then((res) => res.json());
};

export const getCatBreeds = () => {
    return fetch(`${_apiUrl}/cats`).then((res) => res.json());
};

