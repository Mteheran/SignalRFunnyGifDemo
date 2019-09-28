import React, { Component } from 'react';
import dino from './dinosaurio.gif';
import './App.css';
import './Letters.css';
import * as signalR from '@aspnet/signalr';

class App extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
    message : "Esperando mensaje...",
    cssClass: "orange",
    cssClassList : ["red","yellow","blue","orange","purple"]
    }
  }

  componentDidMount = () => {

    const protocol = new signalR.JsonHubProtocol();

    const transport = signalR.HttpTransportType.WebSockets;

    const options = {
      transport,
      logMessageContent: true,
      logger: signalR.LogLevel.Trace
    };

    this.setState({
      connection : new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:5000/message', options)
        .withHubProtocol(protocol)
        .build()
      },()=>
      {    // start connection
        this.state.connection.start().catch(err => console.error(err, 'red'));

        this.state.connection.on('RecieveMessage', this.changeMessage);
      }  );
}


changeMessage = (msg) =>
{
  this.setState({
    message : msg,
    cssClass : this.state.cssClassList[Math.floor(Math.random()*this.state.cssClassList.length)]
  });
}

  render() {
    return (
      <div className="App">
        <header className="App-header">
            <div id="container"><p className={this.state.cssClass}><a> {this.state.message}</a></p></div>
        </header>
      </div>
    );
  }
}

export default App;
