const _apiUrl = "/api/breed";

export const getDogBreeds = () => {
    return fetch(`${_apiUrl}/dogs`).then((res) => res.json());
};



