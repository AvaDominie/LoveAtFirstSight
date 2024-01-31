import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Home from "./Home";
import Dogs from "./animals/Dogs";
import Cats from "./animals/Cats";
import AnimalDetails from "./animals/AnimalDetails";
import UserProfile from "./userProfile/UserProfile";
import UserProfileDetails from "./userProfile/UserProfileDetails";


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
                            <Dogs />
                        </AuthorizedRoute>
                    }
                />
                <Route
                    path="cats"
                    element={
                        <AuthorizedRoute loggedInUser={loggedInUser}>
                            <Cats />
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
