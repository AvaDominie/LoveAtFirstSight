const _apiUrl = "/api/userProfile";


export const getUserProfiles = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const getUserProfileById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const editUserProfile = (userId, updatedUser) => {
    return fetch(`${_apiUrl}/${userId}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(updatedUser),
    }).then((res) => res);
};




