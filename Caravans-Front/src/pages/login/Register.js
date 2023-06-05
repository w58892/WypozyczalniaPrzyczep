import React, { Component } from "react";
import { addUser } from "../../actions/userActions";
import { TextField, Typography, Button, Box } from "@mui/material";

export class Register extends Component {
	state = {
		firstName: "",
		lastName: "",
		email: "",
		password: "",
		errors: []
	};

	handleChange = (e) => {
		this.setState({ [e.target.name]: e.target.value });
	};

	handleRegister= () => {
		const { email, password, password2} = this.state;
		const user = { email, password };
		if(password != password2){
			this.setState({ errors: {Password2: "Hasła muszą być identyczne"}});
			return;
		}
		
		addUser(user).then((res) => {
			if (res && res.status === 200) {
				window.location.href = "/login";
			}
			if (res.errors) {
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
					Rejestracja
				</Typography>
				<Box component="form" sx={{ mt: 1, maxWidth:400 }}>
					<TextField
						margin="normal"
						fullWidth
						id="firstName"
						name="firstName"
						onChange={this.handleChange}
						label="Imię"
						required
						variant="outlined"
						error={!!errors.FirstName}
						helperText={errors.FirstName ? errors.FirstName : ''}
					/>
					<TextField
						margin="normal"
						fullWidth
						id="lastName"
						name="lastName"
						onChange={this.handleChange}
						label="Nazwisko"
						required
						variant="outlined"
						error={!!errors.LastName}
						helperText={errors.LastName ? errors.LastName : ''}
					/> 
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
						onClick={this.handleRegister}
					>
						Załóż konto
					</Button>
				</Box>
			</Box>
		);
	}
}
export default Register;

