const _apiUrl = "/api/animal";

export const getAnimals = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const getDogs = () => {
    return fetch(`${_apiUrl}/allDogs`).then((res) => res.json());
};

export const getCats = () => {
    return fetch(`${_apiUrl}/allCats`).then((res) => res.json());
};

export const getFosteredDogs = () => {
    return fetch(`${_apiUrl}/allFosteredDogs`).then((res) => res.json());
};

export const getFosteredCats = () => {
    return fetch(`${_apiUrl}/allFosteredCats`).then((res) => res.json());
};



