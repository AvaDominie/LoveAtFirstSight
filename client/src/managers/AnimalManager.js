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

export const getDogsByBreed = (breedName) => {
    return fetch(`${_apiUrl}/allDogsBreed/${breedName}`).then((res) => res.json());
};

export const getFosteredDogsByBreed = (breedName) => {
    return fetch(`${_apiUrl}/allFosteredDogsByBreed/${breedName}`).then((res) => res.json());
};

export const getCatsByBreed = (breedName) => {
    return fetch(`${_apiUrl}/allCatsBreed/${breedName}`).then((res) => res.json());
};

export const getFosteredCatsByBreed = (breedName) => {
    return fetch(`${_apiUrl}/allFosteredCatsByBreed/${breedName}`).then((res) => res.json());
};

export const getAnimalById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const updateAnimalAvailability = (animalId) => {
    return fetch(`${_apiUrl}/${animalId}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(animalId),
    });
};