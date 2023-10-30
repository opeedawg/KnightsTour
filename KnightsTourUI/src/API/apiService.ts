/**
 * File:     apiService.ts
 * Service to access all model (common) api calls.
 *
 * @author Chris Chartrand (DXterity Solutions)
 * Generated on January 16, 2023
 */

// Imports
import { api } from 'src/boot/axios';
import { Solution } from 'src/models/Solution';
import { DXResponse } from 'src/models/Support/dxterity';

/**
 * Class: apiService
 *
 * Class to implement any custom api calls.
 *
 */
export class ApiService {
  restPath: string;

  constructor() {
    this.restPath = 'http://localhost:3131/rest/knightsTour/';
    //this.restPath = 'http://opeedawg.ddnsfree.com:420/rest/knightsTour/';
  }

  async signUp(
    emailAddress: string,
    displayName: string,
    userInitials: string,
    password: string
  ): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'signUp', {
      emailAddress: emailAddress,
      displayName: displayName,
      userInitials: userInitials,
      password: password,
    });

    return result.data;
  }

  async signIn(emailAddress: string, password: string): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'signIn', {
      emailAddress: emailAddress,
      password: password,
    });

    return result.data;
  }

  async changePassword(
    memberId: number,
    oldPassword: string,
    newPassword1: string,
    newPassword2: string
  ): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'changePassword', {
      memberId: memberId,
      oldPassword: oldPassword,
      newPassword1: newPassword1,
      newPassword2: newPassword2,
    });

    return result.data;
  }

  async startPuzzle(puzzleId: number, memberId: number): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'startPuzzle', {
      puzzleId: puzzleId,
      memberId: memberId,
    });

    return result.data;
  }

  async recoverPassword(emailAddress: string): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'recoverPassword', {
      emailAddress: emailAddress,
    });

    return result.data;
  }

  async updateSolution(
    solutionId: number,
    path: string,
    note: string
  ): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'updateSolution', {
      solutionId: solutionId,
      path: path,
      note: note,
    });

    return result.data;
  }

  async completeSolution(solutionId: number): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'completeSolution', {
      solutionId: solutionId,
    });

    return result.data;
  }

  async insertNonMemberSolution(solution: Solution): Promise<DXResponse> {
    const result = await api.post(
      this.restPath + 'insertNonMemberSolution',
      solution
    );

    return result.data;
  }

  async getPuzzleRankings(
    puzzleId: number,
    memberId: number
  ): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'getPuzzleRankings', {
      puzzleId: puzzleId,
      memberId: memberId,
    });

    return result.data;
  }

  async communicationSubmit(
    userName: string,
    subject: string,
    emailAddress: string,
    purpose: string,
    body: string
  ): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'communicationSubmit', {
      userName: userName,
      subject: subject,
      emailAddress: emailAddress,
      purpose: purpose,
      body: body,
    });

    return result.data;
  }

  async getRandomPuzzle(
    memberId: number,
    newPuzzlesOnly: boolean,
    difficultyLevelId: number,
    size: string,
    puzzleCode: string
  ): Promise<DXResponse> {
    const result = await api.post(this.restPath + 'getRandomPuzzle', {
      memberId: memberId,
      newPuzzlesOnly: newPuzzlesOnly,
      difficultyLevelId: difficultyLevelId,
      size: size,
      puzzleCode: puzzleCode,
    });

    return result.data;
  }

  async getDailyPuzzle(memberId: number): Promise<DXResponse> {
    const result = await api.get(this.restPath + 'getDailyPuzzle/' + memberId);

    return result.data;
  }

  async getPuzzle(code: string): Promise<DXResponse> {
    const result = await api.get(this.restPath + 'getPuzzle/' + code);

    return result.data;
  }

  async getShareSolution(code: string): Promise<DXResponse> {
    const result = await api.get(this.restPath + 'getShareSolution/' + code);

    return result.data;
  }

  async getMemberStatistics(memberId: number): Promise<DXResponse> {
    const result = await api.get(
      this.restPath + 'getMemberStatistics/' + memberId
    );

    return result.data;
  }

  async getLevels(): Promise<DXResponse> {
    const result = await api.get(this.restPath + 'getLevels');

    return result.data;
  }

  async getDistinctBoardSizes(): Promise<DXResponse> {
    const result = await api.get(this.restPath + 'getDistinctBoardSizes');

    return result.data;
  }
}
