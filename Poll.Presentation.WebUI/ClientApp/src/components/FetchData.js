import React, { Component } from 'react';

export class FetchData extends Component {
  displayName = FetchData.name

  constructor(props) {
    super(props);
      this.state = {
          poll: [], loading: false, filterValue: '', formatedFilters: []
      };
    this.getDataPolls = this.getDataPolls.bind(this);
  }

  handleChange(event) {
      this.setState({ filterValue: event.target.value });
  }

  getDataPolls() {
      debugger;
      this.state.formatedFilters = [];
      this.state.loading = true;
      var rowLines = this.state.filterValue.split("\n");
      for (var i = 0; i < rowLines.length; i++) {
          var item = rowLines[i].split(",");
          if (item[0] && item[1] && item[2] && item[3]) {
              var element = {
                  gender: item[0],
                  age: item[1],
                  studies: item[2],
                  academic_year: item[3]
              };
              this.state.formatedFilters.push(element);
          }
      }
      fetch('api/PollData/Polls', 
          {
              method: "post",
                  headers: {
                      'Accept': 'application/json',
                      'Content-Type': 'application/json'
              },
              body: JSON.stringify({ root: this.state.formatedFilters })
          })
      .then(response => response.json())
          .then(data => {
          this.setState({ poll: JSON.parse(data), loading: false });
      });
  }

  static renderPollsTable(poll) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Case</th>
            <th>Output</th>
          </tr>
        </thead>
        <tbody>
          {poll.map(poll =>
              <tr key={poll.caseValue}>
                <td width="10%">{poll.Case}</td>
                <td width="90%">{poll.Students}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderPollsTable(this.state.poll);
      return (
      <div>
        <h1>Anonymous Poll</h1> 
        <table className='table'>
            <thead>
                <tr>
                    <th>Filter by</th>
                </tr>
            </thead>
            <tbody> 
            <tr>
                <td width="30%"><textarea name="textFilters" rows="5" value={this.state.filterValue} onChange={this.handleChange.bind(this)}></textarea></td>
                <td width="70%"><button type="buttonFiltres" onClick={this.getDataPolls}>Summit!</button></td>
            </tr>
            </tbody>
        </table>
        {contents}
      </div>
    );
  }
}
