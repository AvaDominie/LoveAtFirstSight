import { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
    Button,
    Collapse,
    Nav,
    NavLink,
    NavItem,
    Navbar,
    NavbarBrand,
    NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";
import "./NavBar.css"


export default function NavBar({ loggedInUser, setLoggedInUser }) {
    const [open, setOpen] = useState(false);

    const toggleNavbar = () => setOpen(!open);

    return (
        <div>
            <Navbar color="light" light fixed="true" expand="lg" className="navbar">
                <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
                    <img src={"https://i.pinimg.com/736x/eb/15/f2/eb15f2958017d0410671cb19f7b72f20.jpg"} alt="Lafs Logo" width="200" height="175" />
                </NavbarBrand>
                {loggedInUser ? (
                    <>
                        <NavbarToggler onClick={toggleNavbar} />
                        <Collapse isOpen={open} navbar>
                            <Nav navbar className="navbar-items">
                                <NavItem onClick={() => setOpen(false)}>
                                    <NavLink tag={RRNavLink} to="/" className="navbar-link">
                                        Home
                                    </NavLink>
                                </NavItem>
                                <NavItem onClick={() => setOpen(false)}>
                                    <NavLink tag={RRNavLink} to="/dogs" className="navbar-link">
                                        Dogs
                                    </NavLink>
                                </NavItem>
                                <NavItem onClick={() => setOpen(false)}>
                                    <NavLink tag={RRNavLink} to="/cats" className="navbar-link">
                                        Cats
                                    </NavLink>
                                </NavItem>
                                <NavItem onClick={() => setOpen(false)}>
                                    <NavLink tag={RRNavLink} to="/profile" className="navbar-link">
                                        Profile
                                    </NavLink>
                                </NavItem>
                            </Nav>
                        </Collapse>
                        <Button
                            color="primary"
                            onClick={(e) => {
                                e.preventDefault();
                                setOpen(false);
                                logout().then(() => {
                                    setLoggedInUser(null);
                                    setOpen(false);
                                });
                            }}
                            className="navbar-logout"
                        >
                            Logout
                        </Button>
                    </>
                ) : (
                    <Nav navbar>
                        <NavItem>
                            <NavLink tag={RRNavLink} to="/login" className="navbar-link">
                                <Button color="primary">Login</Button>
                            </NavLink>
                        </NavItem>
                    </Nav>
                )}
            </Navbar>
        </div>
    );
}



