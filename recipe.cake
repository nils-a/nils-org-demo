#load nuget:?package=Cake.Recipe&version=1.1.1

Environment.SetVariableNames();

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "nils-org-demo",
  masterBranchName: "main",
  repositoryOwner: "nils-a",
  repositoryName: "nils-org-demo",
  shouldRunGitVersion: true,
  shouldExecuteGitLink: false,
  shouldRunCodecov: true,
  shouldDeployGraphDocumentation: false,
  shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
  context: Context,
  testCoverageFilter: string.Format("+[{0}*]* -[*.Tests]*", "NilsOrgDemo") // Assembly is called NilsOrgDemo and not nils-org-demo
);

Build.RunDotNetCore();