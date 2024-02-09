import React, { useEffect, useState } from "react";
import { getUserProfileById, editUserProfile } from "../../managers/UserProfileManager";
import { useNavigate } from "react-router-dom";
import "./UserProfile.css"



export default function EditUserProfile({ loggedInUser }) {
    const [user, setUser] = useState(null);

    const [updatedUser, setUpdatedUser] = useState({
        fullName: "",
        email: "",
        address: "",
        userName: ""
    });

    const getUserId = loggedInUser.id;

    const navigate = useNavigate();

    useEffect(() => {
        getUserProfileById(getUserId).then(setUser);
    }, [getUserId]);

    const handleUpdate = (evt) => {

        evt.preventDefault();

        const updatedUserObject = {
            id: getUserId,
            fullName: user.fullName,
            email: user.email,
            address: user.address,
            userName: user.userName
        }

        editUserProfile(getUserId, updatedUserObject).then(() => {
            navigate(`/profile`)
        });
    };

    const handleChange = (evt) => {
        const { name, value } = evt.target;
        setUser({
            ...user,
            [name]: value,
        });
    };

    console.log(user)

    return (
        <form className="container">
            <div className="profile-edit-details">
                <h2>Edit User Profile</h2>
                <hr />
                {user ? (
                    <>
                        <fieldset>
                            <div>
                                <br />
                                <label>Full Name:</label>
                                <input
                                    type="text"
                                    name="fullName"
                                    value={updatedUser.fullName || user.fullName}
                                    onChange={handleChange}
                                />
                            </div>
                            <br />
                        </fieldset>
                        <fieldset>
                            <div>
                                <label>Email:</label>
                                <input
                                    type="text"
                                    name="email"
                                    value={updatedUser.email || user.email}
                                    onChange={handleChange}
                                />
                            </div>
                            <br />
                        </fieldset>
                        <fieldset>
                            <div>
                                <label>Address:</label>
                                <input
                                    type="text"
                                    name="address"
                                    value={updatedUser.address || user.address}
                                    onChange={handleChange}
                                />
                            </div>
                            <br />
                        </fieldset>
                        <fieldset>
                            <div>
                                <label>User Name:</label>
                                <input
                                    type="text"
                                    name="userName"
                                    value={updatedUser.userName || user.userName}
                                    onChange={handleChange}
                                />
                            </div>
                            <br />
                        </fieldset>
                        <button id="edit-profile" onClick={handleUpdate}>
                            Update
                        </button>
                    </>
                ) : (
                    <p>Loading...</p>
                )}
            </div>
        </form>
    );
}
