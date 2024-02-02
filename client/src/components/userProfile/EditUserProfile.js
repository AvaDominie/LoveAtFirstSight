import React, { useEffect, useState } from "react";
import { getUserProfileById, editUserProfile } from "../../managers/UserProfileManager";
import { useNavigate } from "react-router-dom";


export default function EditUserProfile({ loggedInUser }) {
    const [user, setUser] = useState(null);

    const [updatedUser, setUpdatedUser] = useState({
        fullName: "",
        email: "",
        address: "",
        userName: ""
    });

    const getUserId = loggedInUser.id;

    const navigate = useNavigate()

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
        <form>
            <h2>Edit User Profile</h2>
            {user ? (
                <>
                    <fieldset>
                        <div>
                            <label>Full Name:</label>
                            <input
                                type="text"
                                name="fullName"
                                value={updatedUser.fullName || user.fullName}
                                onChange={handleChange}
                            />
                        </div>
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
                    </fieldset>
                    <button className="user-info-edit-btn" onClick={handleUpdate}>
                        Update
                    </button>
                </>
            ) : (
                <p>Loading...</p>
            )}
        </form>
    );
}
