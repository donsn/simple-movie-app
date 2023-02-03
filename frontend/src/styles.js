import { createGlobalStyle } from 'styled-components';
 
const GlobalStyle = createGlobalStyle`
  html {
    box-sizing: border-box;
  }
  body {
    margin: 0;
    padding: 0;
    background: #FFFEFF;
    font-size: 12px;
    font-family: Poppins, 'Sans-Serif';
    font-weight: 400;
  }
`;
 
export default GlobalStyle;