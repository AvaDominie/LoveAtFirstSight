import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Home from "./Home";
import Dogs from "./animals/Dogs";
import Cats from "./animals/Cats";
import AnimalDetails from "./animals/AnimalDetails";
import UserProfileDetails from "./userProfile/UserProfileDetails";
import EditUserProfile from "./userProfile/EditUserProfile";
import AddAnimal from "./animals/AddAnimal";
import EditAnimal from "./animals/EditAnimal";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
    return (
        <Routes>
            <Route path="/">
                <Route
                    index
                    element={
                        <AuthorizedRoute loggedInUser={loggedInUser}>
                            <Home />
                        </AuthorizedRoute>
                    }
                />
                <Route
                    path="dogs"
                    element={
                        <AuthorizedRoute loggedInUser={loggedInUser}>
                            <Dogs loggedInUser={loggedInUser}/>
                        </AuthorizedRoute>
                    }
                />
                <Route
                    path="cats"
                    element={
                        <AuthorizedRoute loggedInUser={loggedInUser}>
                            <Cats loggedInUser={loggedInUser}/>
                        </AuthorizedRoute>
                    }
                />
                <Route
                    path="animalDetails/:animalId"
                    element={
                        <AuthorizedRoute loggedInUser={loggedInUser}>
                            <AnimalDetails loggedInUser={loggedInUser} />
                        </AuthorizedRoute>
                    }
                />
                <Route
                    path="profile"
                    element={
                        <AuthorizedRoute loggedInUser={loggedInUser}>
                            <UserProfileDetails loggedInUser={loggedInUser} />
                        </AuthorizedRoute>
                    }
                />
                <Route
                    path="editUserProfile/:userId"
                    element={
                        <AuthorizedRoute loggedInUser={loggedInUser}>
                            <EditUserProfile loggedInUser={loggedInUser} />
                        </AuthorizedRoute>
                    }
                />
                <Route
                    path="addAnimal"
                    element={
                        <AuthorizedRoute roles={["Employee"]} loggedInUser={loggedInUser}>
                            <AddAnimal loggedInUser={loggedInUser} />
                        </AuthorizedRoute>
                    }
                />
                <Route
                    path="editAnimal/:animalId"
                    element={
                        <AuthorizedRoute roles={["Employee"]} loggedInUser={loggedInUser}>
                            <EditAnimal loggedInUser={loggedInUser} />
                        </AuthorizedRoute>
                    }
                />
                <Route
                    path="login"
                    element={<Login setLoggedInUser={setLoggedInUser} />}
                />
                <Route
                    path="register"
                    element={<Register setLoggedInUser={setLoggedInUser} />}
                />
            </Route>
            <Route path="*" element={<p>Whoops, nothing here...</p>} />
        </Routes>
    );
}


