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
  appVeyorAccountName: "nils-a", // convention would be "nilsa"
  appVeyorProjectSlug: "nils-org-demo", // convention would be "nilsorgdemo"
  shouldRunGitVersion: true,
  shouldExecuteGitLink: false,
  shouldRunCodecov: true,
  shouldDeployGraphDocumentation: false,
  shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
  context: Context,
  testCoverageFilter: string.Format("+[{0}*]* -[*.Tests]*", "NilsOrgDemo") // convention would be nils-org-demo
); 

Build.RunDotNetCore();

// debug!
if(BuildParameters.IsRunningOnAppVeyor && FileExists(BuildParameters.Paths.Files.TestCoverageOutputFilePath))
{
    AppVeyor.UploadArtifact(BuildParameters.Paths.Files.TestCoverageOutputFilePath);
}