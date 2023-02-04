import React from 'react';
import { Link } from 'react-router-dom';
import { Button } from '../../components/buttons';
import { Form } from '../../components/forms';
import { InputField } from '../../components/inputs';
import { FlexContainer } from './styles';

export default function SignupPage() {
  return (
    <FlexContainer>
      <Form>
        <h1>Signup</h1>
        <InputField label="Username" name="username" type="text" />
        <InputField label="Password" name="password" type="password" />
        <Button> Signup</Button>
        <Link to="/login">Already have an account? Login</Link>
      </Form>
    </FlexContainer>
  );
}
