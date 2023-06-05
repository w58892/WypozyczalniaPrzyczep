import React from "react";
import {Toolbar} from "@mui/material";
import { Link } from "react-router-dom";

const handleLogout = () => {
	localStorage.clear();
	window.location.href = "/";
};

const styles={
	color:"black",
	fontSize:20,
	textDecoration: "none",
	marginLeft:30
};

const isNotAuthenticated = (
	<Link
		to="/login"
		style={styles}
	>
		Zaloguj
	</Link>

);

const isAuthenticated = (
	<>
		<Link
			to="/reservations"
			style={styles}
		>
			Moje Rezerwacje
		</Link>
		<Link
			onClick={() => handleLogout()}
			style={styles}
		>
			Wyloguj
		</Link>
	</>
);

export default function Navbar() {
	const token = localStorage.getItem("token");
	let headerLinks;

	if (token) {
		headerLinks = isAuthenticated;
	} else {
		headerLinks = isNotAuthenticated;
	}
	return (
		<Toolbar style={{
			backgroundColor:"#ffffff",
			justifyContent:"space-between",
			position:"fixed",
			width:"100%",
			maxWidth:'1220px',
			top: 0,
			padding:0
		}}>
			<Link to="/" >
				<img src={`/images/logo.png`}
					style={{width: 50}}
				/>
			</Link>
			<Toolbar>{headerLinks}</Toolbar>
		</Toolbar>
	)
};

