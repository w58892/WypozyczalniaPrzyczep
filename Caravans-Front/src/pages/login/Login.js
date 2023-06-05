import React, { Component } from "react";
import { Box, TextField, Typography, Button } from "@mui/material";
import { login, getToken } from "../../actions/userActions";
import { Link } from "react-router-dom";

export class Login extends Component {
	state = {
		email: "",
		password: "",
		errors: []
	};

	handleChange = (e) => {
		this.setState({ [e.target.name]: e.target.value });
	};

	handleLogin = () => {
		const { email, password} = this.state;
		const user = { email, password };
		login(user).then((res) => {
			if (res && res.status === 200) {
				const token = getToken();
				if (token)
					window.location.href = "/";
			}else{
				this.setState({ errors: res.errors });
			}
		});
	};

	render() {
		const errors = this.state.errors;
		return (
			<Box
			sx={{
				marginTop: 8,
				display: 'flex',
				flexDirection: 'column',
				alignItems: 'center',
				"button": {
					backgroundColor: '#841818'
				},
				"button:hover": {
					backgroundColor: '#AB2222'
				}
			}}
			>
				<Typography component="h1" variant="h5">
					Logowanie
				</Typography>
				<Box component="form" sx={{ mt: 1, maxWidth:400 }}>
					<TextField
						margin="normal"
						fullWidth
						id="email"
						name="email"
						type="email"
						onChange={this.handleChange}
						label="Email"
						required
						variant="outlined"
						error={!!errors.Email}
						helperText={errors.Email ? errors.Email : ''}
					/>
					<TextField
						margin="normal"
						fullWidth
						id="password"
						name="password"
						type="password"
						label="Hasło"
						onChange={this.handleChange}
						required
						variant="outlined"
						error={!!errors.Password}
						helperText={errors.Password ? errors.Password : ''}
					/>
					<Button
						fullWidth
						variant="contained"
						sx={{ mt: 3, mb: 2, }}
						onClick={this.handleLogin}
					>
						Zaloguj
					</Button>
					<Link to="/register" style={{
						textDecoration:"none",
						color:"gray"
					}}>
					Załóż konto
					</Link>
				</Box>
			</Box>
		);
	}
}
export default Login;
